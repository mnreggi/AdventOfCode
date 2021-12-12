using System.ComponentModel;

namespace AdventOfCode2021._02
{
    public enum Commands
    {
        [Description("forward")]
        forward,
        [Description("down")]
        down,
        [Description("up")]
        up
    }
}